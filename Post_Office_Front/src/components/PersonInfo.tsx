interface PersonProps {
  name: string;
  address: string;
  phoneNumber: string;
}
interface PersonItemProps {
  info: string;
  person: PersonProps;
}
const PersonInfo = ({ info, person }: PersonItemProps) => {
  return (
    <div className="mb-4">
      <h4>{info}</h4>
      <ul className="list-group">
        <li className="list-group-item"> Ім'я: {person.name}</li>
        <li className="list-group-item">Адреса: {person.address}</li>
        <li className="list-group-item">
          Номер телефону: {person.phoneNumber}
        </li>
      </ul>
    </div>
  );
};

export default PersonInfo;
