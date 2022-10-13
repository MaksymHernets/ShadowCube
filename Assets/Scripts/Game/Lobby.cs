using ShadowCube.DTO;
using System.Collections.Generic;

namespace ShadowCube.Game
{
	public class Lobby
    {
        public int IndexCube = 0;
        public bool IsPrivate = true;
        public List<PlayerDTO> Players = new List<PlayerDTO>();
    }
}
