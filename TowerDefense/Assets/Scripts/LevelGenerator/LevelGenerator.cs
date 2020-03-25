using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	public ColorToPrefab[] colorMappings;

	// Use this for initialization
	void Start () {
		GenerateLevel();
	}

	void GenerateLevel ()
	{
        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                GenerateTile(x, y);
			}
		}
	}

	void GenerateTile (int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
            Debug.Log("colorMapping.color: " + colorMapping.color + " color: " + pixelColor);
			if (colorMapping.color.Equals(pixelColor))
			{
				Vector3 position = new Vector3(x-26.5f, -1, y-17.5f);
				Instantiate(colorMapping.prefab, position, Quaternion.identity);
			}
		}
	}
	
}
