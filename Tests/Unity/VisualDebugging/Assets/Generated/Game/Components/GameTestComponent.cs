//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TestComponent testComponent = new TestComponent();

    public bool isTest {
        get { return HasComponent(GameComponentsLookup.Test); }
        set {
            if(value != isTest) {
                if(value) {
                    AddComponent(GameComponentsLookup.Test, testComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Test);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.Core.IMatcher<GameEntity> _matcherTest;

    public static Entitas.Core.IMatcher<GameEntity> Test {
        get {
            if(_matcherTest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Test);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTest = matcher;
            }

            return _matcherTest;
        }
    }
}
