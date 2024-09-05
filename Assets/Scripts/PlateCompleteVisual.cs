using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectS0_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectS0_GameObject> kitchenObjectS0GameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (KitchenObjectS0_GameObject kitchenObjectS0GameObject in kitchenObjectS0GameObjectList)
        {
                kitchenObjectS0GameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEnventArgs e)
    {
        foreach (KitchenObjectS0_GameObject kitchenObjectS0GameObject in kitchenObjectS0GameObjectList)
        {
            if (kitchenObjectS0GameObject.kitchenObjectSO == e.KitchenObjectSO)
            {
                kitchenObjectS0GameObject.gameObject.SetActive(true);
            }
        }
    }
}
