using ShadowCube.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.Cubes
{
    public abstract class CubeLogic : MonoBehaviour
    {
        [SerializeField] protected Light _light;
        [SerializeField] protected List<WallLogic> _walls;

        protected MegaCubeLogic _megaCubeLogic;
        protected CubeDTO _cube;

        private int CountPlayers = 0;
        private float TimeWait = 10;
        private float TimeLost = 0;

        public void IntCube(MegaCubeLogic megaCubeLogic, CubeDTO cube)
        {
            _megaCubeLogic = megaCubeLogic;
            _cube = cube;

			for (int i = 0; i < _walls.Count; ++i)
			{
                WallDTO wall = new WallDTO();
                wall.id = i;
                wall.number = _cube.id;
                wall.color = _cube.Color;
                _walls[i].IntWall(this, wall);
            }

            _light.color = _cube.Color;
        }

        public virtual void SetColorRoom(Color color)
        {
            foreach (var wall in _walls)
            {
                wall.SetColorPanel(color);
            }
        }

        public void Update()
        {
            if ( CountPlayers == 0 )
            {
                TimeLost += Time.deltaTime;
                if (TimeWait <= TimeLost)
                {
                    CloseAllDoor();
                    StartCoroutine("Wait");
                    TimeLost = 0;
                }
            }
        }

        public virtual void OpenDoor(int indexDoor)
        {
            _walls[indexDoor].ToOpenDoor();
        }

        public virtual void CloseDoor(int indexDoor) 
        {
            _walls[indexDoor].ToCloseDoor();
        }

        public virtual void CloseAllDoor()
        {
            foreach (var wall in _walls)
            {
                wall.ToCloseDoor();
            }
        }

        public void EventOpenedDoor(int indexwall)
        {
            _megaCubeLogic.EventOpenedDoor(_cube.position, indexwall);
        }

        public void EventClosedDoor(int indexwall)
        {
            
        } 

        private void OnTriggerEnter(Collider other)
        {
            if( other.gameObject.GetComponent<Entity>() != null )
            {
                ++CountPlayers;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if ( other.gameObject.GetComponent<Entity>() != null )
            {
                --CountPlayers;
            }
        }
        
        IEnumerator Wait()
        {
            yield return new WaitForSecondsRealtime(4f);
            gameObject.SetActive(false);
        }
    }
}
