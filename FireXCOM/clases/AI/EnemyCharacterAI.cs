using System.Collections.Generic;

public class EnemyCharacterAI
{
    TileManager tileManager;
    int Team;
    List<CharacterObject> Characters;

    public EnemyCharacterAI(TileManager _tileManager, int _team, List<CharacterObject> _characters){
        tileManager = _tileManager;
        Team = _team;
        Characters = _characters;
    }
    public void MakeMoves(){
        foreach(CharacterObject character in Characters){
            
        }
    }
}