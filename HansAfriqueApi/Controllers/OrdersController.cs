using AutoMapper;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Entities.OrderAggregate;
using HansAfriqueApi.Helpers.Extensions;
using HansAfriqueApi.Interface;
using HansAfriqueApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static HansAfriqueApi.Controllers.BaseController;

namespace HansAfriqueApi.Controllers
{
        public class OrdersController : BaseApiController
        {
            private readonly IOrderRepository _orderService;
            private readonly IMapper _mapper;
            public OrdersController(IOrderRepository orderService, IMapper mapper)
            {
                _mapper = mapper;
                _orderService = orderService;
            }

            [HttpPost]
            public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
            {
                var email = HttpContext.User.RetrieveEmailFromPrincipal();

                var address = _mapper.Map<AddressDto, AddressEnt>(orderDto.ShipToAddress);

                var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

                if (order == null) return BadRequest("Problem creating order");

                return Ok(order);
            }

            [HttpGet]
            public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser()
            {
                var email = HttpContext.User.RetrieveEmailFromPrincipal();

                var orders = await _orderService.GetOrdersForUserAsync(email);

                return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Order>> GetOrderByIdForUser(int id)
            {
                var email = HttpContext.User.RetrieveEmailFromPrincipal();

                var order = await _orderService.GetOrderByIdAsync(id, email);

                if (order == null) return NotFound("Problem creating order getting Order by Id ");

                return order;
            }

            [HttpGet("deliveryMethods")]
            public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
            {
                return Ok(await _orderService.GetDeliveryMethodsAsync());
            }
        }
    }
