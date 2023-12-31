﻿using Attendance.Application.DTOs;
using Attendance.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
    }

    [HttpGet]

    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<CustomerDto>> GetCustomer(Guid id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]

    public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerCreateDto customerDto)
    {
        var createdCustomer = await _customerService.CreateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateCustomer(Guid id, CustomerDto customerDto)
    {
        var updatedCustomer = await _customerService.UpdateCustomerAsync(id, customerDto);

        if (updatedCustomer == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
