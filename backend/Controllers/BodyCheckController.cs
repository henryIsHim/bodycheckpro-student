using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BodyCheckWebAPI.Models;

namespace BodyCheckWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyCheckController : ControllerBase
    {
        private readonly BodyCheckDbContext _context;

        public BodyCheckController(BodyCheckDbContext context)
        {
            _context = context;
        }

        // GET: api/BodyCheck/Get
        [HttpGet]
        public async Task<IEnumerable<BodyCheckViewModel>> Get()
        {
            var bodyCheckList = await _context.BodyChecks.OrderByDescending(x => x.Id).ToListAsync();
            return bodyCheckList;
        }

        // GET: api/BodyCheck/Get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var bodyCheck = await _context.BodyChecks.SingleOrDefaultAsync(f => f.Id == id);
                if (bodyCheck == null)
                {
                    return NotFound($"Record with this Id was not found ({id})");
                }
                return Ok(bodyCheck);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing your request.");
            }
        }

        // POST: api/BodyCheck/Post
        [HttpPost]
        public async Task<IActionResult> Post(BodyCheckViewModel addBodyCheckViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }
            try
            {
                BodyCheckViewModel bodyCheckViewModel = new BodyCheckViewModel()
                {
                    StudentId = addBodyCheckViewModel.StudentId,
                    Firstname = addBodyCheckViewModel.Firstname,
                    Lastname = addBodyCheckViewModel.Lastname,
                    HeightCm = addBodyCheckViewModel.HeightCm,
                    WeightKg = addBodyCheckViewModel.WeightKg
                };
                await _context.AddAsync(bodyCheckViewModel);
                await _context.SaveChangesAsync();
                return Ok($"New Body Check Record Created ({bodyCheckViewModel.Firstname} {bodyCheckViewModel.Lastname})");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing your request.");
            }
        }

        // PUT: api/BodyCheck/Put
        [HttpPut]
        public async Task<IActionResult> Put(BodyCheckViewModel editBodyCheckViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }
            try
            {
                var bodyCheck = await _context.BodyChecks.SingleOrDefaultAsync(f => f.Id == editBodyCheckViewModel.Id);
                if (bodyCheck == null)
                {
                    return NotFound($"Body Check with Id {editBodyCheckViewModel.Id} was not found.");
                }

                bodyCheck.StudentId = editBodyCheckViewModel.StudentId;
                bodyCheck.Firstname = editBodyCheckViewModel.Firstname;
                bodyCheck.Lastname = editBodyCheckViewModel.Lastname;
                bodyCheck.HeightCm = editBodyCheckViewModel.HeightCm;
                bodyCheck.WeightKg = editBodyCheckViewModel.WeightKg;
                await _context.SaveChangesAsync();

                return Ok($"Body Check Record Edited ({editBodyCheckViewModel.Firstname} {editBodyCheckViewModel.Lastname})");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing your request.");
            }
        }

        // DELETE: api/BodyCheck/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bodyCheck = await _context.BodyChecks.SingleOrDefaultAsync(f => f.Id == id);
                if (bodyCheck == null)
                {
                    return NotFound($"Body Check with Id {id} was not found.");
                }

                _context.BodyChecks.Remove(bodyCheck);
                await _context.SaveChangesAsync();
                return Ok($"Body Check Record Deleted ({bodyCheck.Firstname} {bodyCheck.Id})");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing your request.");
            }
        }
    }
}
