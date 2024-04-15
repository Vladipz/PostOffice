interface ButtonProps {
  style: string;
  text: string;
  onClick: () => void;
}

const Button = ({ style, text, onClick }: ButtonProps) => {
  return (
    <button className={style} type="button" onClick={onClick}>
      {text}
    </button>
  );
};

export default Button;
