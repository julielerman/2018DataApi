using System;
using System.Collections.Generic;
using System.Linq;

namespace Firefly.Domain {
  public class Character {
   
    public Character (string name) : this() {
      Name = name;
      IsDirty=true;
    }
    private Character () {
      _quotes = new List<Quote> ();
      }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsDirty {get;private set;}
 
    private readonly List<Quote> _quotes = new List<Quote> ();
    public IEnumerable<Quote> Quotes => _quotes.ToList ();
    public void AddQuote (string quoteText) {
       quoteText=StringManipulators.ReplaceBadWordWithAsterisks(quoteText);
      _quotes.Add (new Quote(Id,quoteText));
 
    }
  
    private Entrance _entrance;
    private Entrance Entrance { get { return _entrance; } }
    public void CreateEntrance (int minute, string sceneName, string description) {
      _entrance = new Entrance (Id, minute, sceneName, description);
    }
    public bool HasEntrance => _entrance != null;
    public void ReplaceEntrance(int minute, string sceneName, string description) {
      _entrance.Replace(minute, sceneName, description);
    }
    public string EntranceScene => _entrance?.SceneName;
    }
  }
