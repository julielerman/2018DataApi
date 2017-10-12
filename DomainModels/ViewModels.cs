using System;
using System.Collections.Generic;
using System.Linq;

namespace Firefly.Domain {
  public class CharacterViewModel {
    public string CharacterName { get; set; }
    public List<QuoteViewModel> Quotes { get; set; }
    public EntranceViewModel Entrance { get; set; }
  }
  public class QuoteViewModel {
    public string Text { get;  set; }
  }
  public class EntranceViewModel {
    public int MovieMinute { get; set; }
    public string SceneName { get; set; }
    public string Description { get; set; }
  }
}