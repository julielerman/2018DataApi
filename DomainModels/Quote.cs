using System;

namespace Firefly.Domain
{
  public class Quote
  {
    
    public Quote (Guid characterGuidId,string text) {
      Text = text;
      CharacterGuidId=characterGuidId;
    }
     public int Id { get; private set; }
     public string Text { get; private set; }
     public Guid CharacterGuidId{get;private set;}
     //hidden ORM "concessions"
     private int CharacterId { get;  set; }
     private Quote () { } 
  }

}