using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firefly.Data;
using Firefly.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class CharactersController : Controller { 
   CharacterContext _context;
           public CharactersController (CharacterContext context) {
       _context = context;
       }
       // GET api/values
       [HttpGet]
       public IEnumerable<Character> Get () {
         return _context.Characters.ToList ();
       }
   
       // GET api/values/5
       [HttpGet("{id}",Name="GetChar")]
       public Character Get (int id) {
         return _context.Characters.FindAsync (id).Result;
       }
   
       // POST api/values
       [HttpPost]
       public IActionResult Post ([FromBody] string name) {
         var character = new Character (name);
         _context.Characters.Add (character);
         _context.SaveChanges ();
         return CreatedAtRoute ("GetChar", new { id = character.Id }, character);
       }
   
       // PUT api/values/5
       [HttpPut ("{id}")]
       public void Put (int id, [FromBody] string value) {  
         //????
       }
   
       // DELETE api/values/5
       [HttpDelete ("{id}")]
       public void Delete (int id) {
         var character = _context.Characters.Find (id);
         _context.Characters.Remove (character);
         _context.SaveChangesAsync ();
       }
     }
}
