using System;

namespace Firefly.Domain
{
  public class Quote
  {
    
    public Quote (int characterId,string text) {
      Text = text;
      CharacterId=characterId;
    }
     public int Id { get; private set; }
     public string Text { get; private set; }
     private int CharacterId { get;  set; }
     private Quote () { } 
  }

}