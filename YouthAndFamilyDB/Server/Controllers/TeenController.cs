﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthAndFamilyDB.Shared;

namespace YouthAndFamilyDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeenController : ControllerBase
    {
        static List<HouseChurch> houseChurches = new List<HouseChurch>
        {
            new HouseChurch { Id = 1, Name = "Kinzer"},
            new HouseChurch { Id = 2, Name = "Ammon"},
            new HouseChurch { Id = 3, Name = "Rodriguez"}
        };

        static List<Teen> teens = new List<Teen>
        {
            new Teen { Id = 1, FirstName = "Peter", LastName = "Parker", GradeLevel = 3, HouseChurch = houseChurches[1] },
            new Teen { Id = 2,  FirstName = "Damion", LastName = "Wayne", GradeLevel = 4, HouseChurch = houseChurches[0] },
        };

        [HttpGet("houseChurches")]
        public async Task<IActionResult> GetHouseChurch()
        {
            return Ok(houseChurches);
        }


        [HttpGet]
        public async Task<IActionResult> GetTeens()
        {
            return Ok(teens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleTeen(int id) 
        {
            var teen = teens.FirstOrDefault(t => t.Id == id);
            if (teen == null)
                return NotFound("Teen not found. :-(");

            return Ok(teen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeen(Teen teen)
        {
            teen.Id = teens.Max(t => t.Id + 1);
            teens.Add(teen);

            return Ok(teens);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeen(Teen teen, int id)
        {
            var dbTeen = teens.FirstOrDefault(t => t.Id == id);
            if (dbTeen == null)
                return NotFound("Teen not found. :-(");

            var index = teens.IndexOf(dbTeen);
            teens[index] = teen;

            return Ok(teens);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeen(int id)
        {
            var dbTeen = teens.FirstOrDefault(t => t.Id == id);
            if (dbTeen == null)
                return NotFound("Teen not found. :-(");

            teens.Remove(dbTeen);

            return Ok(teens);
        }
    }
}
