using Eğitim_Portalı.Data;
using Eğitim_Portalı.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eğitim_Portalı.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class EğitimPortalıController : ControllerBase
    {
        private readonly EğitimPortalıDbContext _portalContext;

        private readonly ILogger<EğitimPortalıController> _logger;
        public EğitimPortalıController(ILogger<EğitimPortalıController> logger, EğitimPortalıDbContext portalContext)
        {
            _logger = logger;
            _portalContext = portalContext;
        }

        [HttpGet("eğitimler")]
        public async Task<ActionResult<IEnumerable<Eğitim>>> GetEğitimler()
        {
            return await _portalContext.eğitimler.ToListAsync();
        }

        [HttpGet("kullanıcılar")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> GetKullanıcılar()
        {
            return await _portalContext.kullanıcılar.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Rol>>> GetRollerveYetkiler()
        //{
        //    return await _portalContext.roller.Include(r => r.yetkiler).ToListAsync();
        //}
    }
}