using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))] 
public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D attackCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start ()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChange; // registering this
	}
	
	// Update is called once per frame
	void OnLayerChange (Layer newLayer) { // Only called when layer changes
        var layer = cameraRaycaster.currentlayerHit;
        print("CursorAffordance delegate called. Current pointed layer is: " + layer);
        switch(cameraRaycaster.currentlayerHit)
        {
            case Layer.Walkable:
            Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
            break;

            case Layer.RaycastEndStop:
            Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
            break;

            case Layer.Enemy:
            Cursor.SetCursor(attackCursor, cursorHotspot, CursorMode.Auto);
            break;

            default:
            Debug.LogError("Don't know what cursor to show");
            return;

        } 
        
        //print(cameraRaycaster.layerHit);

	}
}
