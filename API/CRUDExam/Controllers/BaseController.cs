using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDExam.Repo.Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExam.Controllers
{
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly IUnitOfWork _unitofwork;
        protected readonly IRepository<TEntity> _genericRepository;
        public BaseController(IUnitOfWork unitofwork, IRepository<TEntity> genericRepository)
        {
            _unitofwork = unitofwork;
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get() {

            try
            {
                return Ok(await _genericRepository.GetAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }

        }




        [HttpDelete]
        [Route("Delete/{Id}")]
        public virtual async Task<IActionResult> Delete(int Id)
        {

            try
            {
                
                await _genericRepository.RemoveAsync(Id);
                await _unitofwork.SaveAsync();
                return Ok("Registro Removido de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }

        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntity tEntity)
        {

            try
            {
                await _genericRepository.UpdateAsync(tEntity);
                await _unitofwork.SaveAsync();
                return Ok("Registro actualizado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }

        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity tEntity)
        {

            try
            {
                await _genericRepository.AddAsync(tEntity);
                await _unitofwork.SaveAsync();
                return Ok("Registro guardado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ha ocurrido un error, Favor intentar nuevamente");
            }

        }
    }
}
