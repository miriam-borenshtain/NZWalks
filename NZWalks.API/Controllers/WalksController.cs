using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepositories walkRepositories;

        public WalksController(IMapper mapper, IWalkRepositories walkRepositories)
        {
            this.mapper = mapper;
            this.walkRepositories = walkRepositories;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            walkDomainModel = await walkRepositories.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
            
           
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int PageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomainModel = await walkRepositories.GetAllAsync(filterOn, filterQuery, sortBy,
                isAscending ?? true, PageNumber, pageSize);
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepositories.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateRegionRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateRegionRequestDto);
            walkDomainModel = await walkRepositories.UpdateAsync(id, walkDomainModel);
            if (walkRepositories == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedWalkDomainModel = await walkRepositories.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
