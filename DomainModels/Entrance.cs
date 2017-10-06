using System;

namespace SamuraiApp.Domain
{
  public class Entrance
  {
     public Entrance (Guid samuraiGuidId,int movieMinute, string sceneName, string description) {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
      SamuraiGuidId=samuraiGuidId;
    }
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }
    public Guid SamuraiGuidId{get;private set;}
    //hidden ORM "concessions"
     private int SamuraiId { get;  set; }
     private Entrance() { } 
  }
}