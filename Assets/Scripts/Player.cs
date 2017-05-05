using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	[System.NonSerialized]
	public Grid.Position position;
    [System.NonSerialized]
    public bool Walking;

	public IEnumerator SetPosition(List<Grid.Position> path, Vector2 spacing )
	{
        foreach (Grid.Position position in path)
        {
            this.position = position;
            transform.localPosition = position.ToWorldPosition(spacing, 1.0f);
            yield return new WaitForSeconds(0.1f);
        }
	}
    

}
