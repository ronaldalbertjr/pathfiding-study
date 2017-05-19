using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	[System.NonSerialized]
	public Grid.Position position;
    [System.NonSerialized]
    public bool Walking;

	public void SetPosition(Grid.Position toPosition, Vector2 spacing )
	{
            this.position = toPosition;
            transform.localPosition = toPosition.ToWorldPosition(spacing, 1.0f);
	}
    public void goToPosition(List<Grid.Position> path, Vector3 tileSpacing)
    {
        StopAllCoroutines();
        StartCoroutine(IgoToPosition(path, tileSpacing));
    }
    IEnumerator IgoToPosition(List<Grid.Position> path, Vector3 tileSpacing)
    {
        foreach(Grid.Position p in path)
        {
            position = p;
            transform.localPosition = p.ToWorldPosition(tileSpacing, 1.0f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    

}
