using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject[] maps;
  public int moveSpeed = 10;
  Vector3 moveMap = Vector3.zero;
  public GameObject gas;

  void Start()
  {
   moveMap = moveSpeed * Vector3.down;
  }

  void Update()
  {
    foreach (GameObject map in maps)
    {
      map.transform.Translate(moveMap * Time.deltaTime);
      MapUpdate(map);
    }
  }



  void MapUpdate(GameObject map)
  {
    if (map.transform.position.y <= -50)
    {
      //랜덤 Gas 생성 ( 왼쪽,중간, 오른쪽으로 하려면 값을 따로 지정해주면 되지만, 지금은 비행기로 생각했기 때문에 랜덤으로 했습니다)
      int randomx = Random.Range(-8, 8);
      Vector3 randomGasPos = new Vector3(randomx, 0, -1);
      
      // 사용했던 맵 재사용, 발전시키려면 맵을 랜덤하게 생성하고,,, 꺼두고,,, 하면 될 듯 합니다. 
      map.transform.position += new Vector3(0, 90, 0);
      var gasobj = Instantiate(gas, map.transform.position + randomGasPos , map.transform.rotation);
      gasobj.transform.parent = map.transform;
      Destroy(gasobj, 10);
       
    }
  }
}
