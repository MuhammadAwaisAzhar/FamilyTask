using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientPortal.Models;
using ClientPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            this._membersService = membersService;
        }
        // GET: api/<Members>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberViewModel>>> Get()
        {
            try
            {
                return Ok(await _membersService.GetMemberTaskDetailsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong, please try again!" + ex.Message);
            }

        }

        // GET api/<Members>/5
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<MemberViewModel>> Get(Guid id)
        {
            try
            {
                var memberFound = await _membersService.GetByIdAsync(id);
                if (memberFound == null)
                {
                    return BadRequest("Member not found, please check Id and try again.!");
                }
                return Ok(memberFound);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
        // POST api/<Members>
        [HttpPost]
        public async Task<ActionResult<MemberViewModel>> Post(MemberViewModel memberViewModel)
        {
            try
            {
                var createdMember = await _membersService.AddAsync(memberViewModel);
                return CreatedAtAction("Get", new { id = memberViewModel.MemberId }, createdMember);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }

        }
        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, MemberViewModel memberViewModel)
        {
            try
            {
                if (id != memberViewModel.MemberId)
                {
                    return BadRequest("Member Id is not valid, Please try with valid information.!");
                }
                var updatedMember = await _membersService.updateAsync(memberViewModel, id);
                
                if (updatedMember == null)
                    return NoContent();
                else 
                    return Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }

        }
        // DELETE api/<Members>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            try
            {
                await _membersService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing went wrong, Please try again later" + ex.Message);
            }
        }
    }
}
