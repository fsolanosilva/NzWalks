using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.CustomActionFilters;
using NzWalks.API.Data;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;
using NzWalks.API.Repositories;

namespace NzWalks.API.Controllers
{
    // reader@nzwalks.com, Reader@123
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain model
            //var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionsDomain = await regionRepository.GetAllAsync();
            #region old
            // Map Domain MNodels to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}
            #endregion
            // Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET SINGLE REGION (GET REGION BY ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id);
            // Get Region Domain Model From Database
            // var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            #region old
            // Map/Convert Region Domain Model To Region DTO
            /*
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };*/
            #endregion
            // return DTO back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST To Create a new Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //if (ModelState.IsValid)
            //{
            // Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            #region Old
            /*
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            */
            #endregion

            // Use Domain Model to Create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
            // await dbContext.Regions.AddAsync(regionDomainModel);
            // await dbContext.SaveChangesAsync();

            // Map Domain model back to Dto
            #region old
            /*
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            */
            #endregion
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
            //}

            //return BadRequest(ModelState);
        }

        // UPDATE REGION
        // PUT:  https://localhost:portnumber/api/regions/{ID}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            #region
            /*
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl= updateRegionRequestDto.RegionImageUrl
            };
            */
            #endregion

            // Check if region exist
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //  Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            #region old
            // Map DTO to Domain Model
            /*
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            */
            //await dbContext.SaveChangesAsync();
            // Convert Domain Model do DTO
            /*
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
            };
            */
            #endregion

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);

        }

        // DELETE REGION
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
                return NotFound();

            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            // return deleted region back
            // map Domain Model to Dto
            #region old
            /*
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
            };
            */
            #endregion
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }


        #region old
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Auckland Region",
        //            Code = "AKL",
        //            RegionImageUrl = "https://images.pexels.com./photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h750&dpr=1"
        //        },
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Wellington Region",
        //            Code = "WLG",
        //            RegionImageUrl = "https://images.pexels.com./photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h750&dpr=1"
        //        },
        //    };

        //    return Ok(regions);
        //}
        #endregion
    }
}
