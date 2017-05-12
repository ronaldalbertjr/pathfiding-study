using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		Queue<Grid.Position> queue = new Queue<Grid.Position>();
        HashSet<Grid.Position> path = new HashSet<Grid.Position>();
        List<Grid.Position> returnPath = new List<Grid.Position>();
        Grid.Position[,] Tiles = new Grid.Position[tiles.GetLength(0), tiles.GetLength(1)];
		queue.Enqueue(fromPosition);
        Tiles[fromPosition.x, fromPosition.y] = fromPosition;

		while (queue.Count > 0) 
		{
			Grid.Position positionDequeued = queue.Dequeue ();
			if (positionDequeued.Equals(toPosition)) 
			{
                returnPath.Add(positionDequeued);
                while(positionDequeued.x != fromPosition.x || positionDequeued.y != fromPosition.y)
                {
                    positionDequeued = Tiles[positionDequeued.x, positionDequeued.y];
                    returnPath.Add(positionDequeued);
                }
                returnPath.Reverse();
                break;
            } 
			else 
			{
                if (Tile.InsideGrid(new Grid.Position(positionDequeued.x, positionDequeued.y + 1), tiles)
                   && !path.Contains(new Grid.Position(positionDequeued.x, positionDequeued.y + 1)))
                {
                    queue.Enqueue(new Grid.Position(positionDequeued.x, positionDequeued.y + 1));
                    path.Add(positionDequeued);
                    Tiles[positionDequeued.x, positionDequeued.y + 1] = positionDequeued;
                }
                if (Tile.InsideGrid(new Grid.Position(positionDequeued.x, positionDequeued.y - 1), tiles)
                   && !path.Contains(new Grid.Position(positionDequeued.x, positionDequeued.y - 1)))
                {
                    queue.Enqueue(new Grid.Position(positionDequeued.x, positionDequeued.y - 1));
                    path.Add(positionDequeued);
                    Tiles[positionDequeued.x, positionDequeued.y - 1] = positionDequeued;
                }
                if (Tile.InsideGrid(new Grid.Position(positionDequeued.x + 1, positionDequeued.y), tiles)
                   && !path.Contains(new Grid.Position(positionDequeued.x + 1, positionDequeued.y)))
                {
                    queue.Enqueue(new Grid.Position(positionDequeued.x + 1, positionDequeued.y));
                    path.Add(positionDequeued);
                    Tiles[positionDequeued.x + 1, positionDequeued.y] = positionDequeued;
                }
                if (Tile.InsideGrid(new Grid.Position(positionDequeued.x - 1, positionDequeued.y), tiles)
                   && !path.Contains(new Grid.Position(positionDequeued.x - 1, positionDequeued.y)))
                {
                    queue.Enqueue(new Grid.Position(positionDequeued.x - 1, positionDequeued.y));
                    path.Add(positionDequeued);
                    Tiles[positionDequeued.x - 1, positionDequeued.y] = positionDequeued;
                }
			}
        }
        return returnPath;
	}

}
