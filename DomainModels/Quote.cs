using System;

namespace SamuraiApp.Domain
{
  public class Quote
  {
    
    public Quote (Guid samuraiGuidId,string text) {
      Text = text;
      SamuraiGuidId=samuraiGuidId;
    }
     public int Id { get; private set; }
     public string Text { get; private set; }
     public Guid SamuraiGuidId{get;private set;}
     //hidden ORM "concessions"
     private int SamuraiId { get;  set; }
     private Quote () { } 
  }

}