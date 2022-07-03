import { FormControl, RadioGroup, FormControlLabel, Radio } from "@mui/material";

interface Props {
    options: any[];
    onChange: (event: any) => void;
    selectedValue: string;
}

export default function RadioButtonGroup({options, onChange, selectedValue}: Props) {
    return (
        <FormControl component="fieldset">
            <RadioGroup onChange={onChange} value={selectedValue}>
              {options.map(({values, label}) => (
                <FormControlLabel value={values} control={<Radio />} label={label} key={values}/>
              ))}
            </RadioGroup>
          </FormControl>
    )
}