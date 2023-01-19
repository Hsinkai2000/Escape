using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class MainDoorScript : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
        public int locked = 1;

		void Start()
		{
			open = false;
		}

		void OnMouseOver()
		{
			Player = GameObject.FindWithTag("Player").transform;
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
                                if(doorIsLocked()){
                                    // displayLock();
			                        print("Door is locked");
                                }else{
								StartCoroutine(opening());
                                }
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
                                    if(doorIsLocked()){
                                        // displayLock();
			                            print("Door is locked");
                                    }else{
									StartCoroutine(closing());
                                    }
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


        bool doorIsLocked(){
            switch(locked){
                case 1:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }
	}
}