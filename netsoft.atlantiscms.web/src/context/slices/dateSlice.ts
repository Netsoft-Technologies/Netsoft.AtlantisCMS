import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface DateState {
  selectedDate: Date | undefined;
}

const initialState: DateState = {
  selectedDate: new Date(),
};

const dateSlice = createSlice({
  name: "date",
  initialState,
  reducers: {
    setDate(state, action: PayloadAction<Date | undefined>) {
      state.selectedDate = action.payload;
    },
  },
});

export const { setDate } = dateSlice.actions;
export default dateSlice.reducer;
