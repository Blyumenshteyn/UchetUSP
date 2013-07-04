using System.Collections.Generic;
using System;

namespace UchetUSP
{
    class xlsAssemblyOrder : ExcelClass
    {
        private string templateName = @"assemblyOrder.XLT";

        private string _orderNum;
        Dictionary<string, string> _D = new Dictionary<string, string>();


        public xlsAssemblyOrder(string num)
        {
            _orderNum = num;
        }

        //—Œ«ƒ¿“‹ ÕŒ¬€… ƒŒ ”Ã≈Õ“
        public void createDocument()
        {
            HashCode.HashCode.CheckFileByHash(templateName);

            if (System.IO.File.Exists(Program.PathString + "\\" + templateName))
            {
                NewDocument(templateName);

                getProperties();
                fillDocument();
                Dictionary<string, string> DictElements = new Dictionary<string, string>();
                DictElements = _ASSEMBLY_ELEMENTS.getElementsDict(_ASSEMBLY_ORDERS.getAssId(_orderNum));
                _fillElements(DictElements);

                this.Visible = true;
            }
        }


        void getProperties()
        {
            _D.Add("NUM", _orderNum);
            _D.Add("CREATION_DATE", _ASSEMBLY_ORDERS.getCreationDate(_orderNum).ToShortDateString());
            _D.Add("DEMAND_DATE", _ASSEMBLY_ORDERS.getDemandDate(_orderNum).ToShortDateString());
            _D.Add("TZ_NUM", _ASSEMBLY_ORDERS.getTZnumber(_orderNum));

            int wSCode = _ASSEMBLY_ORDERS.getWorkshopCode(_orderNum);
            if (wSCode != 0)
            {
                _D.Add("WORKSHOP_CODE", wSCode.ToString());
            }

            if (_ASSEMBLY_ORDERS.isTZ(_orderNum))
            {
                string idDoc = _ASSEMBLY_ORDERS.getTZId(_orderNum);
                string productCode = _ASSEMBLY_ORDERS.getProductCode_TZ(idDoc);
                if (productCode != "0")
                {
                    _D.Add("PRODUCT_CODE", productCode);
                }
                _D.Add("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle_TZ(idDoc));
            }
            else
            {
                _D.Add("PRODUCT_CODE", _ASSEMBLY_ORDERS.getProductCode(_orderNum).ToString());
                _D.Add("PART_TITLE", _ASSEMBLY_ORDERS.getPartTitle(_orderNum));
            }
            
            _D.Add("PART_NAME", _ASSEMBLY_ORDERS.getPartName(_orderNum));
            
            _D.Add("TECH_OPERATION_NAME", _ASSEMBLY_ORDERS.getTechOperationName(_orderNum));
            _D.Add("PARTS_COUNT", _ASSEMBLY_ORDERS.getPartsCount(_orderNum).ToString());
            _D.Add("CUSTOMER_POSITION", _ASSEMBLY_ORDERS.getCustomerPosition(_orderNum));
            _D.Add("CUSTOMER_SURNAME", _ASSEMBLY_ORDERS.getCustomerSurname(_orderNum));
            _D.Add("CREATOR_SURNAME", _ASSEMBLY_ORDERS.getCreatorSurname(_orderNum));

            int assNum = _ASSEMBLY_ORDERS.getAssNum(_orderNum);
            if (assNum != 0)
	        {
                 _D.Add("ASSEMBLY_NUM", assNum.ToString());
	        }

            DateTime nullDate = new DateTime(1, 1, 1);
            DateTime date = _ASSEMBLY_ORDERS.getAssDeliveryDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_DELIVERY_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_GETER_POSITION", _ASSEMBLY_ORDERS.getAssGeterPosition(_orderNum));
            _D.Add("ASSEMBLY_GETER_SURNAME", _ASSEMBLY_ORDERS.getAssGeterSurname(_orderNum));

            date = _ASSEMBLY_ORDERS.getAssPlannedReturnDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_PLANNED_RETURN_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_CREATOR_SURNAME", _ASSEMBLY_ORDERS.getAssCreatorSurname(_orderNum));
            _D.Add("ASSEMBLY_GIVER_SURNAME", _ASSEMBLY_ORDERS.getAssGiverSurname(_orderNum));
            _D.Add("TECH_CONDITIONS", _ASSEMBLY_ORDERS.getTechConditions(_orderNum));
            _D.Add("TECH_CONDITIONS_POSITION", _ASSEMBLY_ORDERS.getTechConditionsPosition(_orderNum));
            _D.Add("TECH_CONDITIONS_SURNAME", _ASSEMBLY_ORDERS.getTechConditionsSurname(_orderNum));

            date = _ASSEMBLY_ORDERS.getAssCreationDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_CREATION_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_SECTOR_NUM", _ASSEMBLY_ORDERS.getAssSectorNum(_orderNum));

            date = _ASSEMBLY_ORDERS.getAssReturnDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_RETURN_DATE", date.ToShortDateString());
            }

            setUSPParams();
            _D.Add("BRIGADIER_SURNAME", _ASSEMBLY_ORDERS.getBrigadierSurname(_orderNum));

            _D.Add("ASSEMBLY_RETURN_GIVER_SURNAME", _ASSEMBLY_ORDERS.getAssReturnGiverSurname(_orderNum).ToString());
            _D.Add("ASSEMBLY_RETURN_GETER_SURNAME", _ASSEMBLY_ORDERS.getAssReturnGeterSurname(_orderNum).ToString());
        }

        void setUSPParams()
        {
            int assElCount = _ASSEMBLY_ORDERS.getElementsCount(_orderNum);
            if (assElCount != 0)
            {
                _D.Add("ASSEMBLY_ELEMENTS_COUNT", assElCount.ToString());
            }

            int nStraps = _ASSEMBLY_ORDERS.getStrapsCount(_orderNum);
            if (nStraps != 0)
            {
                _D.Add("ASSEMBLY_STRAPS_COUNT", nStraps.ToString());
            }

            int nNuts = _ASSEMBLY_ORDERS.getNutsCount(_orderNum);
            if (nNuts != 0)
            {
                _D.Add("ASSEMBLY_NUTS_COUNT", nNuts.ToString());
            }

            int nSpElem = _ASSEMBLY_ORDERS.getSpecialDowelsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_SPECIAL_DOWELS_COUNT", nSpElem.ToString());
            }

            nSpElem = _ASSEMBLY_ORDERS.getSpecialElementsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_SPECIAL_ELEME_COUNT", nSpElem.ToString());
            }

            nSpElem = _ASSEMBLY_ORDERS.getDimensionsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_DIMENSIONS_COUNT", nSpElem.ToString());
            }

            nSpElem = _ASSEMBLY_ORDERS.getDifficultyGroup(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_DIFFICULTY_GROUP", nSpElem.ToString());
            }
        }

        void fillDocument()
        {
            _writeFromD("NUM", "E4");
            _writeFromD("NUM", "D24");
            _writeFromD("CREATION_DATE", "G4");
            _writeFromD("CREATION_DATE", "A39");
            _writeFromD("DEMAND_DATE", "K8");
            _writeFromD("DEMAND_DATE", "C39");
            _writeFromD("TZ_NUM", "D8");
            _writeFromD("TZ_NUM", "D27");
            _writeFromD("WORKSHOP_CODE", "H4");
            _writeFromD("WORKSHOP_CODE", "H24");
            _writeFromD("PRODUCT_CODE", "I8");
            _writeFromD("PRODUCT_CODE", "I24");
            _writeFromD("PART_NAME", "A8");
            _writeFromD("PART_NAME", "A27");
            _writeFromD("PART_TITLE", "I4");
            _writeFromD("PART_TITLE", "J24");
            _writeFromD("TECH_OPERATION_NAME", "G8");
            _writeFromD("TECH_OPERATION_NAME", "G27");
            _writeFromD("PARTS_COUNT", "J8");
            _writeFromD("PARTS_COUNT", "I27");
            _writeFromD("CUSTOMER_POSITION", "A19");
            _writeFromD("CUSTOMER_SURNAME", "G19");
            _writeFromD("CUSTOMER_SURNAME", "K27");
            _writeFromD("CREATOR_SURNAME", "K19");
            _writeFromD("ASSEMBLY_NUM", "G24");
            _writeFromD("ASSEMBLY_NUM", "U15");
            _writeFromD("ASSEMBLY_DELIVERY_DATE", "A36");
            _writeFromD("ASSEMBLY_GETER_POSITION", "D36");
            _writeFromD("ASSEMBLY_GETER_SURNAME", "I36");
            _writeFromD("ASSEMBLY_PLANNED_RETURN_DATE", "K36");
            _writeFromD("ASSEMBLY_CREATOR_SURNAME", "F39");
            _writeFromD("ASSEMBLY_GIVER_SURNAME", "K39");
            if (_D.ContainsKey("TECH_CONDITIONS"))
            {
                addValueToCell("O3", _D["TECH_CONDITIONS"]);
            }
            _writeFromD("TECH_CONDITIONS_POSITION", "N8");
            _writeFromD("TECH_CONDITIONS_SURNAME", "AE8");
            _writeFromD("ASSEMBLY_CREATION_DATE", "N15");
            _writeFromD("ASSEMBLY_SECTOR_NUM", "S15");

            _writeFromD("ASSEMBLY_ELEMENTS_COUNT", "W15");
            _writeFromD("ASSEMBLY_STRAPS_COUNT", "Z15");
            _writeFromD("ASSEMBLY_NUTS_COUNT", "AC15");
            _writeFromD("ASSEMBLY_SPECIAL_DOWELS_COUNT", "AE15");
            _writeFromD("ASSEMBLY_SPECIAL_ELEMEN_COUNT", "AG15");
            _writeFromD("ASSEMBLY_DIMENSIONS_COUNT", "AJ15");
            _writeFromD("ASSEMBLY_DIFFICULTY_GROUP", "AL15");

            _writeFromD("ASSEMBLY_CREATOR_SURNAME", "V19");
            _writeFromD("BRIGADIER_SURNAME", "AG19");

            _writeFromD("ASSEMBLY_RETURN_DATE", "N37");
            _writeFromD("ASSEMBLY_RETURN_DATE", "AA37");
            _writeFromD("ASSEMBLY_RETURN_GIVER_SURNAME", "V37");
            _writeFromD("ASSEMBLY_RETURN_GETER_SURNAME", "AJ37");
        }

        void _fillElements(Dictionary<string, string> Dict)
        {
            int id = 1;
            int firstRow = 25; 

            string letter1 = "N";
            string letter2 = "P";
            string letter3 = "V";

            int row = firstRow;
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                WriteDataToCell(letter1 + row, id.ToString());
                WriteDataToCell(letter2 + row, Pair.Key);
                WriteDataToCell(letter3 + row, Pair.Value);

                row++;
                if (id == 18)
                {
                    row = firstRow;
                    letter1 = "AF";
                    letter2 = "AG";
                    letter3 = "AM";
                }
                else
                {
                    if (id == 9)
                    {
                        row = firstRow;
                        letter1 = "W";
                        letter2 = "X";
                        letter3 = "AE";
                    }
                }
                id++;
            }
        }

        void _writeFromD(string key, string adress)
        {
            if (_D.ContainsKey(key))
                WriteDataToCell(adress, _D[key].Trim());
        }
    }
}