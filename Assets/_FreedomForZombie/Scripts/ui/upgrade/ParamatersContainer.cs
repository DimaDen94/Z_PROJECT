using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamatersContainer : MonoBehaviour
{
    [SerializeField] private UnitParameterView _unitParameterViewPrefab;
    [SerializeField] private ParametersIconListSO _parametersIconList;

    private List<UnitParameterView> unitParameterViews = new List<UnitParameterView>();

    public void Render(List<FullUnitParametersValue> parametersValues)
    {
        ClearContainer();
        CreateItems(parametersValues);
    }
    private void ClearContainer()
    {

        for (int i = unitParameterViews.Count - 1; i >= 0; i--)
        {
            Destroy(unitParameterViews[i].gameObject);
        }
        unitParameterViews.Clear();
    }
    private void CreateItems(List<FullUnitParametersValue> parametersValues) {
        foreach (FullUnitParametersValue parametersValue in parametersValues)
            if (parametersValue.Value != 0)
            {
                UnitParameterView item = Instantiate(_unitParameterViewPrefab, transform);
                item.Render(_parametersIconList.FindIcon(parametersValue.parameterType), parametersValue.parameterType.ToString(), (int)(parametersValue.Value), parametersValue.BonusValue);
                unitParameterViews.Add(item);
            }
        for (int i = 0; i < 6 - parametersValues.Count; i++)
        {
            UnitParameterView empty = Instantiate(_unitParameterViewPrefab, transform);
            unitParameterViews.Add(empty);
            empty.gameObject.SetActive(false);
        }

    }
}
