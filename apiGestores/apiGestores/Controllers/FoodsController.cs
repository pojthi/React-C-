using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    public class FoodsController : Controller
    {
        private readonly AppDbContext context;
        public FoodsController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.foods.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="Foods")]
        public ActionResult Get(int id)
        {
            try
            {
                var foods = context.foods.FirstOrDefault(g => g.Id == id);
                return Ok(foods);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Foods foods)
        {
            try
            {
                context.foods.Add(foods);
                context.SaveChanges();
                return CreatedAtRoute("Foods", new { id = foods.Id }, foods);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Foods foods)
        {
            try
            {
                if (foods.Id == id)
                {
                    context.Entry(foods).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("Foods", new { id = foods.Id }, foods);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var foods = context.foods.FirstOrDefault(g => g.Id == id);
                if (foods != null)
                {
                    context.foods.Remove(foods);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
