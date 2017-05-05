using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		var path = new List<Grid.Position>();

        Grid.Position pathPos = new Grid.Position();
        pathPos.x = fromPosition.x;
        pathPos.y = fromPosition.y;
        path.Add(fromPosition);
        while (pathPos.x != toPosition.x || pathPos.y != toPosition.y)
        {
            if (pathPos.x < toPosition.x)
            {
                pathPos.x = pathPos.x + 1;
            }
            else if(pathPos.x > toPosition.x)
            {
                pathPos.x = pathPos.x - 1;
            }

            if (pathPos.y < toPosition.y)
            {
                pathPos.y = pathPos.y + 1;
            }
            else if (pathPos.y > toPosition.y)
            {
                pathPos.y = pathPos.y - 1;
            }
            Grid.Position newPos = pathPos;
            path.Add(newPos);
        }
        path.Add(toPosition);
        return path;
	}
}
