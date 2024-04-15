interface PersonInfoInputProps {
  info: string;
  onChange: (newPersonInfo: {
    name: string;
    address: string;
    phoneNumber: string;
  }) => void;
  value: {
    name: string;
    address: string;
    phoneNumber: string;
  };
}

const PersonInfoInput: React.FC<PersonInfoInputProps> = ({
  info,
  onChange,
  value,
}: PersonInfoInputProps) => {
  return (
    <div className="mb-4">
      <h4>{info}</h4>
      <h6>Ім'я</h6>
      <input
        className="form-control mb-2 form-control"
        type="text"
        placeholder="Name"
        onChange={(e) => onChange({ ...value, name: e.target.value })}
        value={value.name}
      />
      <h6>Адреса</h6>

      <input
        className="form-control mb-2 form-control"
        type="text"
        placeholder="Address"
        onChange={(e) => onChange({ ...value, address: e.target.value })}
        value={value.address}
      />
      <h6>Номер телефону</h6>
      <input
        className="form-control mb-2 form-control"
        type="text"
        placeholder="Phone Number"
        onChange={(e) => onChange({ ...value, phoneNumber: e.target.value })}
        value={value.phoneNumber}
      />
    </div>
  );
};

export default PersonInfoInput;
