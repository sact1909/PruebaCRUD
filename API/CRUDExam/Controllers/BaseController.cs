using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDExam.Repo.Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExam.Controllers
{
    public class BaseController<TEntity, TEntityDTO> : ControllerBase where TEntity : class
    {
        protected readonly IUnitOfWork _unitofwork;
        protected readonly IRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;


        public BaseController(IUnitOfWork unitofwork, IRepository<TEntity> genericRepository, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {

            try
            {
                var model = await _genericRepository.GetAsync();
                var modelDTOList = _mapper.Map<List<TEntityDTO>>(model);
                return Ok(modelDTOList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
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
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntityDTO tEntity)
        {

            try
            {
                var model = _mapper.Map<TEntity>(tEntity);
                await _genericRepository.UpdateAsync(model);
                await _unitofwork.SaveAsync();
                return Ok("Registro actualizado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntityDTO tEntity)
        {

            try
            {
                var model = _mapper.Map<TEntity>(tEntity);
                await _genericRepository.AddAsync(model);
                await _unitofwork.SaveAsync();
                return Ok("Registro guardado de manera Exitosa");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error, Favor intentar nuevamente", ErrorType = ex.Message });
            }

        }

    }
}
