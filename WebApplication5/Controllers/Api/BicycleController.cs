using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers.Api
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class BicycleController : Controller
    {
        private readonly ShopContext shopContext;

        public BicycleController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicycle>>> Get()
        {
            return await shopContext.Bicycles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> Get(int id)
        {
            Bicycle bicycle = await shopContext.Bicycles.FirstOrDefaultAsync(x => x.BicycleID == id);
            if(bicycle == null)
            {
                return NotFound();
            }
            return Ok(bicycle);
        }

        [HttpPost]
        public async Task<ActionResult<Bicycle>> Post(Bicycle bicycle)
        {
            shopContext.Bicycles.Add(bicycle);
            await shopContext.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpPut]
        public async Task<ActionResult<Bicycle>> Put(Bicycle bicycle)
        {
            shopContext.Update(bicycle);
            await shopContext.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> Delete(int id)
        {
            Bicycle bicycle = await shopContext.Bicycles.FirstOrDefaultAsync(x => x.BicycleID == id);
            if (bicycle==null)
            {
                return NotFound();
            }

            shopContext.Bicycles.Remove(bicycle);

            await shopContext.SaveChangesAsync();

            return Ok(bicycle);

        }

    }
}
