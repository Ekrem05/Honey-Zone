﻿using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Messages.ExceptionMessages;

using static HoneyZoneMvc.Common.Messages.SuccessfulMessages;
namespace HoneyZoneMvc.Areas.Admin.Controllers
{

    public class OrderController : BaseAdminController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index([FromQuery] AllOrdersQueryModel queryModel)
        {
            try
            {
                AllOrdersQueryModel vm = await orderService.AllAsync(queryModel.Day,
                queryModel.Month,
                queryModel.Year,
                queryModel.SearchTerm,
                queryModel.SortBy,
                queryModel.CurrentPage,
                queryModel.OrdersPerPage);
                queryModel.TotalOrdersCount = vm.TotalOrdersCount;
                queryModel.Orders = vm.Orders;
                return View(queryModel);
            }
            catch (Exception)
            {
                //Add Admin Error Page
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }

        }
        [HttpGet]
        [ActionName("OrderInformation")]
        public async Task<IActionResult> OrderInformation(string Id)
        {
            if (Id == null)
            {
                TempData["Message"] = IdNull;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                var orderInfo = await orderService.DetailsAsync(Id);
                return View(orderInfo);
            }
            catch (Exception)
            {
                TempData["Error"] = OrderMessages.OrderNotFound;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [ActionName("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(string Id)
        {
            try
            {
                var order = await orderService.OrderByIdAsync(Id);
                return View(order);
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralException;
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }
        }
        [HttpPost]
        [ActionName("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(ChangeOrderStatusViewModel vm)
        {
            try
            {
                await orderService.ChangeStatusAsync(vm);
                TempData["Success"] = OrderStatusChanged;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        [ActionName("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(string Id)
        {
            if (Id == null)
            {
                TempData["Error"] = IdNull;
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await orderService.DeleteAsync(Id);
                TempData["Success"] = OrderDeleted;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["Error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
