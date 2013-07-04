using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Класс инструментария
/// </summary>
class Instrumentary
{
    static Dictionary<string, string> _D;

    /// <summary>
    /// Метод, возвращающий Dictionary для формирования 1-ой страницы листа заказа по номеру листа заказа
    /// </summary>
    /// <param name="num">Номер листа заказа</param>
    /// <returns></returns>
    public static Dictionary<string, string> setDictOrder1(string num)
    {
        _D = new Dictionary<string, string>();

        _setD("NUM", num);
        DateTime date = _ASSEMBLY_ORDERS.getCreationDate(num);
        if (date != new DateTime(1,1,1))
	    {
            _setD("CREATION_DATE", date.Date);
	    }
        
        int wSCode = _ASSEMBLY_ORDERS.getWorkshopCode(num);
        if (wSCode != 0)
        {
            _setD("WORKSHOP_CODE", wSCode);
        }

        _setD("PART_NAME", _ASSEMBLY_ORDERS.getPartName(num));
        _setD("TZ_NUM", _ASSEMBLY_ORDERS.getTZnumber(num));
        _setD("TECH_OPERATION_NAME", _ASSEMBLY_ORDERS.getTechOperationName(num));
        _setD("PARTS_COUNT", _ASSEMBLY_ORDERS.getPartsCount(num));

        if (_ASSEMBLY_ORDERS.isTZ(num))
        {
            string idTZ = _ASSEMBLY_ORDERS.getTZId(num);
            _setD("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle_TZ(idTZ));
            _setD("PRODUCT_CODE", _ASSEMBLY_ORDERS.getProductCode_TZ(idTZ));
        }
        else
        {
            _setD("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle(num));
            _setD("PRODUCT_CODE", _ASSEMBLY_ORDERS.getProductCode(num));
        }

        date = _ASSEMBLY_ORDERS.getDemandDate(num);
        if (date != new DateTime(1,1,1))
	    {
            _setD("DEMAND_DATE", date.Date.ToShortDateString());
	    }
        
        _setD("CUSTOMER_POSITION", _ASSEMBLY_ORDERS.getCustomerPosition(num));
        _setD("CUSTOMER_SURNAME", _ASSEMBLY_ORDERS.getCustomerSurname(num));
        _setD("CREATOR_SURNAME", _ASSEMBLY_ORDERS.getCreatorSurname(num));

        _setD("TECH_CONDITIONS", _ASSEMBLY_ORDERS.getTechConditions(num));
        _setD("TECH_CONDITIONS_POSITION", _ASSEMBLY_ORDERS.getTechConditionsPosition(num));
        _setD("TECH_CONDITIONS_SURNAME", _ASSEMBLY_ORDERS.getTechConditionsSurname(num));

        date = _ASSEMBLY_ORDERS.getAssCreationDate(num);
        if (date != new DateTime(1,1,1))
	    {
            _setD("ASSEMBLY_CREATION_DATE", date.Date);
        }

        
        _setD("SECTOR_NUM", _ASSEMBLY_ORDERS.getSectorNum(num));

        int iVal = _ASSEMBLY_ORDERS.getAssNum(num);
        if (iVal != 0)
        {
            _setD("ASSEMBLY_NUM", iVal);
        }
        

        int assElCount = _ASSEMBLY_ORDERS.getElementsCount(num);
        if (assElCount != 0)
        {
            _setD("ASSEMBLY_ELEMENTS_COUNT", assElCount);
        }

        int nStraps = _ASSEMBLY_ORDERS.getStrapsCount(num);
        if (nStraps != 0)
        {
            _setD("ASSEMBLY_STRAPS_COUNT", nStraps);
        }

        int nNuts = _ASSEMBLY_ORDERS.getNutsCount(num);
        if (nNuts != 0)
        {
            _setD("ASSEMBLY_NUTS_COUNT", nNuts);
        }

        int nSpElem = _ASSEMBLY_ORDERS.getSpecialDowelsCount(num);
        if (nSpElem != 0)
        {
            _setD("ASSEMBLY_SPECIAL_DOWELS_COUNT", nSpElem);
        }

        nSpElem = _ASSEMBLY_ORDERS.getSpecialElementsCount(num);
        if (nSpElem != 0)
        {
            _setD("ASSEMBLY_SPECIAL_ELEME_COUNT", nSpElem);
        }

        nSpElem = _ASSEMBLY_ORDERS.getDimensionsCount(num);
        if (nSpElem != 0)
        {
            _setD("ASSEMBLY_DIMENSIONS_COUNT", nSpElem);
        }

        nSpElem = _ASSEMBLY_ORDERS.getDifficultyGroup(num);
        if (nSpElem != 0)
        {
            _setD("ASSEMBLY_DIFFICULTY_GROUP", nSpElem);
        }
        

        _setD("ASSEMBLY_CREATOR_SURNAME", _ASSEMBLY_ORDERS.getAssCreatorSurname(num));
        _setD("BRIGADIER_SURNAME", _ASSEMBLY_ORDERS.getBrigadierSurname(num));

        return _D;
    }

    /// <summary>
    /// Метод, возвращающий 2 Dictionary для формирования 2-ой страницы листа заказа по номеру листа заказа
    /// </summary>
    /// <param name="num">Номер листа заказа</param>
    /// <param name="ElementsDict">Dictionary со списком элементов</param>
    /// <returns></returns>
    public static Dictionary<string, string> setDictOrder2(string num, out Dictionary<string, string> ElementsDict)
    {
        _D = new Dictionary<string, string>();

        _setD("NUM", num);
        int iVal = _ASSEMBLY_ORDERS.getAssNum(num);
        if (iVal != 0)
        {
            _setD("ASSEMBLY_NUM", iVal);
        }
        int wSCode = _ASSEMBLY_ORDERS.getWorkshopCode(num);
        if (wSCode != 0)
        {
            _setD("WORKSHOP_CODE", wSCode);
        }
        _setD("PART_NAME", _ASSEMBLY_ORDERS.getPartName(num));
        _setD("TZ_NUM", _ASSEMBLY_ORDERS.getTZnumber(num));
        _setD("TECH_OPERATION_NAME", _ASSEMBLY_ORDERS.getTechOperationName(num));
        _setD("PARTS_COUNT", _ASSEMBLY_ORDERS.getPartsCount(num));
        _setD("CUSTOMER_SURNAME", _ASSEMBLY_ORDERS.getCustomerSurname(num));

        if (_ASSEMBLY_ORDERS.isTZ(num))
        {
            string idTZ = _ASSEMBLY_ORDERS.getTZId(num);
            _setD("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle_TZ(idTZ));
            _setD("PRODUCT_CODE", _ASSEMBLY_ORDERS.getProductCode_TZ(idTZ));
        }
        else
        {
            _setD("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle(num));
            _setD("PRODUCT_CODE", _ASSEMBLY_ORDERS.getProductCode(num));
        }

        _setD("ASSEMBLY_DELIVERY_DATE", _ASSEMBLY_ORDERS.getAssDeliveryDate(num));
        _setD("ASSEMBLY_GETER_POSITION", _ASSEMBLY_ORDERS.getAssGeterPosition(num));
        _setD("ASSEMBLY_GETER_SURNAME", _ASSEMBLY_ORDERS.getAssGeterSurname(num));
        _setD("ASSEMBLY_PLANNED_RETURN_DATE", _ASSEMBLY_ORDERS.getAssPlannedReturnDate(num));

        DateTime date = _ASSEMBLY_ORDERS.getCreationDate(num);
        if (date != new DateTime(1, 1, 1))
        {
            _setD("CREATION_DATE", date.Date);
        }
        date = _ASSEMBLY_ORDERS.getDemandDate(num);
        if (date != new DateTime(1, 1, 1))
        {
            _setD("DEMAND_DATE", date.Date);
        }
        _setD("ASSEMBLY_CREATOR_SURNAME", _ASSEMBLY_ORDERS.getAssCreatorSurname(num));
        _setD("CREATOR_SURNAME", _ASSEMBLY_ORDERS.getCreatorSurname(num));

        int assId = _ASSEMBLY_ORDERS.getAssId(num);
        ElementsDict = _ASSEMBLY_ELEMENTS.getElementsDict(assId);

        return _D;
    }

    /// <summary>
    /// Метод возвращает Dictionary для формирования листов ТЗ на ВПП
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static Dictionary<string, string> setDictTZ(string VPPNum, int pos)
    {
        _D = new Dictionary<string, string>();

        int nTZs = _ASSEMBLY_ORDERS.getNTZs(VPPNum);

        int i = pos;
            _setD("number1", _VPP_TZ.getNum(VPPNum, i));
            _setD("workShopCode1", _VPP_TZ.getWorkshopCode(VPPNum, i));
            _setD("productCode1", _VPP_TZ.getProductCode(VPPNum, i));
            _setD("VPPNumber1", VPPNum);
            _setD("queue1", _VPP_TZ.getQueue(VPPNum, i));
            _setD("classficCode1", _VPP_TZ.getClassCode(VPPNum, i));
            _setD("equipTitle1", _VPP_TZ.getEquipName(VPPNum, i));
            _setD("drawingTitle1", _VPP_TZ.getDrawning(VPPNum, i));
            _setD("deliveryCondition1", _VPP_TZ.getDelivery(VPPNum, i));
            _setD("manufactLocation1", _VPP_TZ.getManufactLocation(VPPNum, i));
            _setD("plantList1", _VPP_TZ.getPlantList(VPPNum, i));
            _setD("basing1", _VPP_TZ.getBasing(VPPNum, i));
            _setD("techRequirements1", _VPP_TZ.getTechRequirements(VPPNum, i));
            _setD("position1", i);

            if (SQLOracle.getTZSketch(VPPNum, pos))
            {
                _setD("SKETCH_PATH", UchetUSP.Program.PathString + @"/" + VPPNum + "-" + pos + ".xls");
            }

        return _D;
    }

    public static int getSumListValues(Dictionary<string, string> Dict)
    {
        int sum = 0;
        foreach (KeyValuePair<string, string> Pair in Dict)
        {
            sum += int.Parse(Pair.Value);
        }
        return sum;
    }



    static void _setD(string key, object value)
    {
        string sValue;
        if (value == null)
        {
            sValue = "";
        }
        else
        {
            sValue = value.ToString();
        }

        if (_D.ContainsKey(key))
            _D[key] = sValue;
        else
            _D.Add(key, sValue);
    }
}
