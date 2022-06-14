import { timers } from "jquery";
import axios from "axios";

const updateProductType = 'ADD_PRODUCT';
const finishUpdateProductType = 'FINISH_ADD_PRODUCT'
const initialState = { isUpdateing: false };
const apiProduct = 'https://localhost:5011/api/Product';

//https://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid#answer-2117523
function createGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

export const actionCreators = {
    updateProduct: (id, name, desc, price, inStock, categoryId) => async (dispatch, getState) => {
        dispatch({ type: updateProductType });
        await axios.put(apiProduct, {
            "id": id,
            "createdDate": new Date().toISOString,
            "updatedDate": new Date().toISOString,
            "creatorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "pubished": true,
            "name": name,
            "desc": desc,
            "price": price,
            "inStock": inStock,
            "isFeatured": true,
            "categoryId": categoryId
        });
        dispatch({ type: finishUpdateProductType })
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === updateProductType) {
        return {
            ...state,
            isUpdateing: true
        };
    }

    if (action.type === finishUpdateProductType) {
        return {
            ...state,
            isUpdateing: false
        };
    }

  return state;
};
