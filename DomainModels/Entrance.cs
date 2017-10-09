using System;

namespace Firefly.Domain
{
  public class Entrance
  {
     public Entrance (int characterId,int movieMinute, string sceneName, string description) {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
      CharacterId=characterId;
    }
    public void Replace (int movieMinute, string sceneName, string description){
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
    }
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }
    private int CharacterId { get;  set; }
    private Entrance() { } 
  }
}