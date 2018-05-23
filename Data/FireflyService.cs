using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Firefly.Data;
using Firefly.Domain;
using Microsoft.EntityFrameworkCore;

public class FireflyService {

  private CharacterContext _context;

  public FireflyService (CharacterContext context) {
    _context = context;
  }
  
  public string CreateNewCharacter (string name) {
    var character = new Character (name);
    _context.Characters.Add (character);
    _context.SaveChanges ();
    return character.Id.ToString();
  }
  
  public string CreateNewCharacter (string name, int entranceMinute, string entranceSceneName, string entranceDescription) { 
    var character = new Character (name); 
    character.CreateEntrance (entranceMinute, entranceSceneName, entranceDescription);
    _context.Characters.Add (character);
    _context.SaveChanges ();
    return character.Id.ToString();
  }

public string InsertCharacterGraph (CharacterViewModel characterJson) { 
    if (characterJson.CharacterName == null) { return "Invalid json"; } 
    var character = new Character (characterJson.CharacterName); 
    var entrance = characterJson.Entrance; 
    if (entrance != null) { 
      character.CreateEntrance (entrance.MovieMinute, entrance.SceneName, entrance.Description); 
    } 
    foreach (var quote in characterJson.Quotes) {
      if (quote.Text!=null){
        character.AddQuote (quote.Text);
      }
    }
    _context.Characters.Add (character);
    _context.SaveChanges ();
    return character.Id.ToString ();
  }

  public  int AddQuoteToCharacter(int characterId, string quoteText) {
    var character = GetCharacter (characterId);
    if(character is null){
     return 0;
    }
    character.AddQuote (quoteText);
    _context.Entry(character.Quotes.First()).State=EntityState.Added;
    return  _context.SaveChanges();
  }

  public int AddEntranceToCharacter (int characterId, int entranceMinute, string entranceSceneName, string entranceDescription) {
    var character = _context.Characters.Include("Entrance").FirstOrDefault(c=>c.Id==characterId); 
    if(character is null){ 
      return 0; 
     } 
     if(character.HasEntrance){
       return 0;
     }
    character.CreateEntrance (entranceMinute, entranceSceneName, entranceDescription);
    return  _context.SaveChanges();
  }

  public int ReplaceEntranceForCharacter (int characterId, int entranceMinute, string entranceSceneName, string entranceDescription) {
    var character = _context.Characters.Include("Entrance").FirstOrDefault(c=>c.Id==characterId);
    if(character is null){
     return 0;
    }
    if(character.HasEntrance){
     character.ReplaceEntrance (entranceMinute, entranceSceneName, entranceDescription);
    }
    return  _context.SaveChanges();
  }

  public Character GetFullCharacterDetails (int characterId) {
    var character = _context.Characters.Include(c=>c.Quotes).Include("Entrance")
      .FirstOrDefault (c => c.Id == characterId);
    return character;
  }

  public List<String[]> GetListOfCharacterNamesAndIds () {
    return _context.Characters
    .Select (c => new String[] { c.Name, c.Id.ToString() }).ToList ();
  }

  public async Task<int>  AddQuoteToCharacterAsync (int characterId, string quoteText) {
    var character = GetCharacter (characterId);
    if(character is null){
     return 0;
    }
    character.AddQuote (quoteText);
    return await _context.SaveChangesAsync ();
  }

  private Character GetCharacter (int characterId) {
    return _context.Characters.Find(characterId);
    
  }
}