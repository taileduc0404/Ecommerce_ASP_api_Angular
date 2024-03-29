﻿using AutoMapper;
using Ecom.API.Errors;
using Ecom.API.Helper;
using Ecom.Core.DTOs;
using Ecom.Core.Interfaces;
using Ecom.Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IUnitOfWork _u;
		private readonly IMapper _mapper;

		public ProductsController(IUnitOfWork u, IMapper mapper)
		{
			this._u = u;
			this._mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllProducts([FromQuery] ProductParams productParams)
		{
			//var res = await _u.ProductRepository.GetAllAsync(x => x.Category);
			var res = await _u.ProductRepository.GetAll(productParams);
			var result = _mapper.Map<IReadOnlyList<ProductDto>>(res);
			var totalItem = res.Count();

			return Ok(new Pagination<ProductDto>(productParams.PageNumber, productParams.PageSize, totalItem, result));
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(BaseCommonResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await _u.ProductRepository.GetByIdAsync(id, x => x.Category);
			if (product == null)
			{
				return NotFound(new BaseCommonResponse(404));
			}
			var res = _mapper.Map<ProductDto>(product);
			return Ok(res);
		}

		[HttpPost()]
		public async Task<ActionResult> AddProduct([FromForm] AddProductDto productDto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var res = await _u.ProductRepository.AddAsync(productDto);
					return res ? Ok(productDto) : BadRequest(res);
				}
				return BadRequest(productDto);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}

		}

		[HttpPut]
		public async Task<ActionResult> UpdateProduct(int id, [FromForm] UpdateProductDto dto)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var res = await _u.ProductRepository.UpdateAsync(id, dto);
					return res ? Ok(dto) : BadRequest();
				}
				return BadRequest(dto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteProduct(int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var res = await _u.ProductRepository.DeleteAsyncWithPicture(id);
					return Ok("Product Deleted");
				}
				return NotFound("Product Not Found");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
