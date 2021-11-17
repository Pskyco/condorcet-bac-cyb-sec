using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.Entities;
using WebApplication.Infrastructure.Contexts;

namespace WebApplication.API.Controllers
{
    [ApiController]
    [Route("pcrtest")]
    public class PcrTestController : ControllerBase
    {
        private readonly ILogger<PcrTestController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public PcrTestController(ILogger<PcrTestController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get the list of pcr tests
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PcrTest>), (int) HttpStatusCode.OK)]
        public ActionResult Get()
        {
            return Ok(_dbContext.PcrTests
                .Include(x => x.PerformerPerson)
                .ToList());
        }

        /// <summary>
        /// Get the pcr test with specified id
        /// </summary>
        /// <param name="id">id of the pcr test</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PcrTest), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public ActionResult Get(Guid id)
        {
            PcrTest pcrTest = null;

            if (id != Guid.Empty)
                pcrTest = _dbContext.PcrTests.Find(id);

            if (pcrTest == null)
                return NotFound(); // 404

            return Ok(pcrTest);
        }

        /// <summary>
        /// Create a pcr test with given model
        /// </summary>
        /// <param name="pcrTest">pcr test model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public ActionResult Post(PcrTest pcrTest)
        {
            try
            {
                // return StatusCode(200);
                // return StatusCode((int) HttpStatusCode.OK);

                if (pcrTest == null)
                    return BadRequest();

                _dbContext.Add(pcrTest);
                _dbContext.SaveChanges();

                // return Ok();
                // return StatusCode((int) HttpStatusCode.OK);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Delete the pcr test with specified id
        /// </summary>
        /// <param name="id">id of the pcr test</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public ActionResult Delete(Guid id)
        {
            try
            {
                PcrTest pcrTestEntity = null;

                if (id != Guid.Empty)
                    pcrTestEntity = _dbContext.PcrTests.Find(id);

                if (pcrTestEntity == null)
                    return NotFound(); // 404

                _dbContext.Remove(pcrTestEntity);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        
        /// <summary>
        /// Update the pcr test with the given id
        /// </summary>
        /// <param name="id">id of the pcr test</param>
        /// <param name="pcrTest">pcr test model</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.Created)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public ActionResult Put(Guid id, PcrTest pcrTest)
        {
            try
            {
                if (pcrTest == null)
                    return BadRequest();
                
                PcrTest pcrTestEntity = null;

                if (id != Guid.Empty)
                    pcrTestEntity = _dbContext.PcrTests.Find(id);

                if (pcrTestEntity == null)
                    return NotFound(); // 404

                pcrTestEntity.Code = pcrTest.Code;
                pcrTestEntity.Comment = pcrTest.Comment;
                pcrTestEntity.Result = pcrTest.Result;
                pcrTestEntity.AnalysisDate = pcrTest.AnalysisDate;
                pcrTestEntity.ReceptionDate = pcrTest.ReceptionDate;
                pcrTestEntity.PerformerPersonId = pcrTest.PerformerPersonId;
                
                _dbContext.Update(pcrTest);
                _dbContext.SaveChanges();

                // return Ok();
                // return StatusCode((int) HttpStatusCode.OK);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}