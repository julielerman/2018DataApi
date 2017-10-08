using System;

namespace Firefly.Domain
{
  public class Entrance
  {
     public Entrance (Guid characterGuidId,int movieMinute, string sceneName, string description) {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
      CharacterGuidId=characterGuidId;
    }
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }
    public Guid CharacterGuidId{get;private set;}
    //hidden ORM "concessions"
     private int CharacterId { get;  set; }
     private Entrance() { } 
  }
}