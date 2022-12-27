using BuisnessLayer.Interfaces;
using DataEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IFileBO _FileBO;
        public FilesController(IFileBO fileBO)
        {
            _FileBO = fileBO;
        }

        // GET api/files
        [HttpGet]
        public ActionResult<List<FileData>> Get()
        {
            List<FileData> res = _FileBO.GetAllFiles();
            if (res != null) return Ok(res);
            return BadRequest();
        }

        // POST api/files
        [HttpPost]
        public ActionResult<bool> Post([FromBody] FileData file)
        {
            bool res = _FileBO.SaveFile(file);
            if (res) return Ok(res);
            return BadRequest();
        }
    }
}
