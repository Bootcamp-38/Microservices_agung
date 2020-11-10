﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using User.Microservice.Repositories.Interface;

namespace User.Microservice.Bases
{
    public class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        protected readonly IConfiguration _configuration;
        public BaseController(TRepository repository, IConfiguration configuration) 
        {
            this._configuration = configuration;
            this._repository = repository; 

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Forgot(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            var update = await _repository.Forgot(entity);
            return Ok(update);
        }

        [HttpGet]
        public async Task<ActionResult<TEntity>> Get(TEntity entity)
        {
            var get = await _repository.Get(entity);
            if (get == null)
            {
                return NotFound();
            }

            var claims = new[]
           {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", get.Email),
            };
            //return Ok(new { data = get });
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            //return Ok(new { data = get });


        }


        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            var result = await _repository.Put(entity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var delete = await _repository.Delete(id);
            if (delete == null)
            {
                return NotFound();
            }
            return delete;
        }
    }
}
