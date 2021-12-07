using AspNetCoreMvc.Client.Domain.Interfaces.Services;
using AspNetCoreMvc.Client.Domain.Models;
using AspNetCoreMvc.Client.Domain.Notifications;
using AspNetCoreMvc.Client.WebApp.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Client.WebApp.Controllers
{
    public class ClientController : MainController
    {
        private readonly IClientService _clientService;
        private readonly INotifierService _notifierService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper, INotifierService notifierService)
        {
            _clientService = clientService;
            _mapper = mapper;
            _notifierService = notifierService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var result = await _clientService.ToList();

            return View(_mapper.Map<IEnumerable<ClientViewModel>>(result));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(ClientPhisycalViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            if(!string.IsNullOrEmpty(viewModel.CelSmartPhone))
                viewModel.Phones.Add(new PhoneViewModel() { ClientId = viewModel.Id, Ddd = viewModel.CelSmartPhone[..2], Number = viewModel.CelSmartPhone[2..], PhoneType = 1 });

            if (!string.IsNullOrEmpty(viewModel.CelHome))
                viewModel.Phones.Add(new PhoneViewModel() { ClientId = viewModel.Id, Ddd = viewModel.CelHome[..2], Number = viewModel.CelHome[2..], PhoneType = 2 });
            
            if (!string.IsNullOrEmpty(viewModel.CelCommercial))
                viewModel.Phones.Add(new PhoneViewModel() { ClientId = viewModel.Id, Ddd = viewModel.CelCommercial[..2], Number = viewModel.CelCommercial[2..], PhoneType = 3 });

            await _clientService.NewClient(_mapper.Map<ClientPhysical>(viewModel));

            if (_notifierService.HasAny())
            {
                foreach (var item in _notifierService.GetAll())
                {
                    ModelState.AddModelError(string.Empty, item.Erro);
                }
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
