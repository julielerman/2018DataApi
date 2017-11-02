using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Firefly.Domain
{
  public class CharacterViewModel
  {
    public string CharacterName { get; set; }
    public List<QuoteViewModel> Quotes { get; set; }
    [JsonProperty(PropertyName = "Entrance", Required = Required.Default)]
    public EntranceViewModel Entrance { get; set; }
  }
  public class QuoteViewModel
  {
    public string Text { get; set; }
  }
  public class EntranceViewModel
  {
    [JsonProperty(PropertyName = "MovieMinute", Required = Required.Default)]
    public int MovieMinute { get; set; }
    [JsonProperty(PropertyName = "SceneName", Required = Required.Default)]
    public string SceneName { get; set; }
    [JsonProperty(PropertyName = "Description", Required = Required.Default)]
    public string Description { get; set; }
  }
}