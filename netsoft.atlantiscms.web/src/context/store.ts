import { configureStore } from "@reduxjs/toolkit";
import dateReducer from "./slices/dateSlice";

const store = configureStore({
  reducer: {
    date: dateReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
