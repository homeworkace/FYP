using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour
{
	#region Private
	[SerializeField]
	private List<FOWRevealer> _revealers;
	[SerializeField]
	private int _width;
	[SerializeField]
	private int _height;
	[SerializeField]
	private Vector2 _mapSize;
	[SerializeField]
	private Material _fogMaterial;

	private Texture2D _shadowMap;
	private Color32[] _pixels;
    #endregion

    public GameObject player_instance;
    public GameObject[] player_storage = null;

	private void Awake()
	{
		_shadowMap = new Texture2D(_width, _height, TextureFormat.RGB24, false);

		_pixels = _shadowMap.GetPixels32();

		for (var i = 0; i < _pixels.Length; ++i)
		{
			_pixels[i] = Color.black;
		}

		_shadowMap.SetPixels32(_pixels);
		_shadowMap.Apply();

		_fogMaterial.SetTexture("_ShadowMap", _shadowMap);
	}

	private void Update()
	{

        if (!player_instance)
        {
            player_storage = null;
            player_storage = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
            player_storage = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in player_storage)
            {
                if (!player)
                    continue;

                if (player.GetComponent<PhotonView>().IsMine)
                {
                    player_instance = player;
                    break;
                }
            }
        }
        else
        {
            UpdateRevealer();
        }

		for(var i = 0; i < _pixels.Length; ++i)
		{
			_pixels[i].r = 0;
		}

		UpdateShadowMap();

		_shadowMap.SetPixels32(_pixels);
		_shadowMap.Apply();
	}

    private void UpdateRevealer()
    {
        foreach (var unit in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (!unit)
                continue;

            if (unit.GetComponent<EnemyBase>().faction == player_instance.GetComponent<PlayerDetails>().faction)
            {
                if (!_revealers.Contains(unit.GetComponent<FOWRevealer>()))
                {
                    _revealers.Add(unit.GetComponent<FOWRevealer>());
                }
            }
        }

        foreach (var revealer in _revealers)
        {
            if (!revealer)
                continue;

            if (!revealer.gameObject)
            {
                _revealers.Remove(revealer);
            }
        }

    }

	private void UpdateShadowMap()
	{
		foreach (var revealer in _revealers)
		{
			DrawFilledMidpointCircleSinglePixelVisit((int)revealer.transform.position.x, (int)revealer.transform.position.z, revealer.sight);
		}
	}

	private void DrawFilledMidpointCircleSinglePixelVisit(int centerX, int centerY, int radius)
	{
	int x = Mathf.RoundToInt(radius * (_width / _mapSize.x));
	int y = 0;
	int radiusError = 1 - x;

	centerX = Mathf.RoundToInt(75 + centerX * (_width / _mapSize.x));
	centerY = Mathf.RoundToInt(-75 + centerY * (_height / _mapSize.y));

	while (x >= y)
	{
		int startX = -x + centerX;
		int endX = x + centerX;
		FillRow(startX, endX, y + centerY);
		if (y != 0)
		{
			FillRow(startX, endX, -y + centerY);
		}

		++y;

		if (radiusError < 0)
		{
			radiusError += 2 * y + 1;
		}
		else
		{
			if (x >= y)
			{
				startX = -y + 1 + centerX;
				endX = y - 1 + centerX;
				FillRow(startX, endX, x + centerY);
				FillRow(startX, endX, -x + centerY);
			}
			--x;
			radiusError += 2 * (y - x + 1);
		}
	}
    }

	private void FillRow(int startX, int endX, int row)
	{
		int index;
		for (var x = startX; x < endX; ++x)
		{
			index = (x + row * _width);

            if (index > -1 && index < _pixels.Length)
			{
                
                _pixels[index].r = 255;
				_pixels[index].g = 255;
                
			}
		}
	}

	private bool HeightCheck(int x, int y, int height)
	{


		return height > 0;
	}

	private void OnDestroy()
	{
		_shadowMap = null;
		_pixels = null;
	}
}
