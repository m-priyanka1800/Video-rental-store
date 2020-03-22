using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            IEnumerable<CustomerDTO> customers = _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
            return customers;
        }

        //GET /api/customer/id
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //POST /api/customer/id
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.ID = customer.ID;

            return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDTO.ID);
        }

        //PUT /api/customer/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDTO,customerInDb);

            _context.SaveChanges();
            return Ok("Customer updated successfully.");
        }

        //DELETE /api/customer/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDB == null)
                return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
            return Ok("Customer deleted successfully.");

        }
    }
}
