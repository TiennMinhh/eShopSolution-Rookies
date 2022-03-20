import { timers } from "jquery";
import axios from "axios";

const addProductImageType = 'ADD_PRODUCT_IMAGE';
const finishAddProductImageType = 'FINISH_ADD_PRODUCT_IMAGE'
const initialState = { isAdding: false };
const apiProductImage = 'https://localhost:5011/api/ProductImage';

//https://stackoverflow.com/questions/105034/how-to-create-a-guid-uuid#answer-2117523
function createGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

export const actionCreators = {
    addProductImage: (imageUrl, title, productId) => async (dispatch, getState) => {
        dispatch({ type: addProductImageType });
        await axios.post(apiProductImage, {
            "id": createGUID(),
            "createdDate": new Date().toISOString,
            "updatedDate": new Date().toISOString,
            "creatorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "pubished": true,
            "imageUrl": imageUrl,
            "title": title,
            "productId": productId
        });
        dispatch({ type: finishAddProductImageType })
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === addProductImageType) {
        return {
            ...state,
            isAdding: true
        };
    }

    if (action.type === finishAddProductImageType) {
        return {
            ...state,
            isAdding: false
        };
    }

  return state;
};
