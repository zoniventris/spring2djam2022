using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Flower : TileBase
{
    public string displayName;
    public Sprite flowerSprite;
    public Sprite sproutSprite;
    public Sprite seedSprite;
    public int valueMultiplier;
    public bool canBuySeeds;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        FlowerState flowerstate = tilemap.GetComponent<FlowerState>();
        if (flowerstate == null)
        {
            Debug.LogError($"Failed to display flower at {position}: Tilemap has no associated FlowerState.");
            return;
        }
        FlowerState.GrowthStage stage = flowerstate.GetGrowthStage(position);
        if (stage == FlowerState.GrowthStage.NoFlower)
        {
            Debug.LogError($"Failed to display flower at {position}: Growth stage set to 'No Flower'");
            return;
        }
        tileData.sprite = stage == FlowerState.GrowthStage.Sprout ? sproutSprite : flowerSprite;
    }
}